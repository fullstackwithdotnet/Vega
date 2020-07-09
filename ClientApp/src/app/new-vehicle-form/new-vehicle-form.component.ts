
import { Component, OnInit, Inject } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { Vehicle, SaveVehicle, Contact } from '../Models/Vehicle';
import * as _ from 'underscore';

@Component({
  selector: 'app-new-vehicle-form',
  templateUrl: './new-vehicle-form.component.html',
  styleUrls: ['./new-vehicle-form.component.css']
})
export class NewVehicleFormComponent implements OnInit {
  makes;
  models;
  features;
  selectedFeatures: any[];
  vehicle: SaveVehicle = {
    id: 0,
    makeId: 0,
    modelId: 0,
    isRegistered: false,
    features: [],
    contact: {
      name: '',
      phone: '',
      email: ''
    }
  };


  constructor(private vehicleService: VehicleService,
    private route: ActivatedRoute, private router: Router) {

    this.selectedFeatures = [];
    this.route.params
      .subscribe(p => {
        this.vehicle.id = +p['id'];
      });
  }

  ngOnInit() {

    const sources = [
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures()
    ];

    if (this.vehicle.id) {
      sources.push(this.vehicleService.GetVehicle(this.vehicle.id));
    }


    forkJoin(sources)
      .subscribe(data => {
        this.makes = data[0];
        this.features = data[1];
        if (this.vehicle.id) {
          this.setVehicle(data[2] as Vehicle);
          this.populateModels();
        }
      });
  }

  setVehicle(v: Vehicle) {
    this.vehicle.makeId = v.make.id;
    this.vehicle.modelId = v.model.id;
    this.vehicle.isRegistered = v.isRegistered;
    this.vehicle.features = _.pluck(v.features, 'id');
    this.vehicle.contact = v.contact;
  }

  LoadModels(event) {
    this.populateModels();
    delete this.vehicle.modelId;
  }

  private populateModels() {
    const selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
  }

  deleteVehicle() {
    if (confirm('Are you sure?')) {
      this.vehicleService.delete(this.vehicle.id)
        .subscribe(v => {
           this.router.navigate(['/']);
        });
    }
  }


  onFeatureToggle(featureId: number, event: { target: { checked: any; }; }) {

    if (event.target.checked) {
      this.vehicle.features.push(featureId);
    } else {
      const index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  AddVehicle(event) {

    this.vehicle.id = 0;
    console.log(this.vehicle);
    this.vehicleService.Add(this.vehicle)
      .subscribe(
        res => {
          console.log(res);
        }
      );
  }
}

interface Make {
  id: number;
  name: string;
  models: Model[];
}

interface Model {
  id: number;
  name: string;
}
