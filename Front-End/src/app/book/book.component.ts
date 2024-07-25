import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../services/category.service';
import { SubCategoryService } from '../services/sub-category.service';

@Component({
  selector: 'app-book',
  standalone: true,
  imports: [],
  templateUrl: './book.component.html',
  styleUrl: './book.component.scss'
})
export class BookComponent implements OnInit {
  categories: any = [];
  subCategories: any = [];

  constructor(
    private gategoryService: CategoryService,
    private subGategoryService: SubCategoryService,

  ) { }

  ngOnInit() {
    this.gategoryService.getAll().subscribe((res: any) => {
      this.categories = res;
      console.log(this.categories);

    });
  }

  onCategoryChange(event: any) {
    const categoryId = event.target.value;
    this.subGategoryService.get(categoryId).subscribe((res: any) => {
      this.subCategories = res;
      console.log(this.subCategories);

    });

  }
}
