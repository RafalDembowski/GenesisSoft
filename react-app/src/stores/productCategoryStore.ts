import {  makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { ProductCategoryDropdownItem } from '../models/productCategory';

export default class ProductCategoryStore{

    productCategoryDropdownItems: ProductCategoryDropdownItem[] = [];
    loadingProductCategory = false;

    constructor(){
        makeAutoObservable(this)
    }

    getProductCategoryDropdownItems = async () => {
        this.loadingProductCategory = true;
        try{

            const productCategoryDropdownItems = await agent.ProductCategories.dropDowItems();

            runInAction(() => {
                this.productCategoryDropdownItems = productCategoryDropdownItems;
                this.loadingProductCategory = false;
            })
            return productCategoryDropdownItems;
        }catch(error){
            console.log(error)
            runInAction(() => this.loadingProductCategory = false)
        }
    }


}