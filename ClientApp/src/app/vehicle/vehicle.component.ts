import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';
import { Vehicle } from '../Models/Vehicle';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent implements OnInit {
  vehicles: Vehicle[];
  filteredVehicles: Vehicle[];
  makes;
  filter: any = {
    pageSize: 3,
    totalItems: 10
  };
  columns = [
    { title: 'Id' },
    { title: 'Contact Name', key: 'contactName', isSortable: true },
    { title: 'Make', key: 'make', isSortable: true },
    { title: 'Model', key: 'model', isSortable: true },
    {}
  ];

  constructor(private vehicleService: VehicleService) {
  }

  ngOnInit() {
    forkJoin(
      [this.vehicleService.GetAllVehicles(this.filter),
      this.vehicleService.getMakes()
      ]
    ).subscribe(data => {
      this.vehicles = this.filteredVehicles = data[0].items as Vehicle[];
      this.filter.totalItems = data[0].totalItems;
      this.makes = data[1];
      console.log(this.totalItems);
    });
  }

  OnFilterVehicles() {
    this.PopulateVehicles();
  }

  private PopulateVehicles() {
    this.vehicleService.GetAllVehicles(this.filter)
      .subscribe(result => {
        this.filteredVehicles = result.items as Vehicle[];
        this.filter.totalItems  = result.totalItems;
      });
  }

  ResetFilters() {
    this.filter = {};
    this.filteredVehicles = this.vehicles;
  }

  SortBy(columnName) {
    if (this.filter.sortBy === columnName) {
      this.filter.isSortAscending = !this.filter.isSortAscending;
    } else {
      this.filter.sortBy = columnName;
      this.filter.isSortAscending = true;
    }

    this.PopulateVehicles();
  }

  OnPageChanged(page: number) {
    this.filter.page = page;
    this.filter.page = page;
    this.PopulateVehicles();
  }


}
