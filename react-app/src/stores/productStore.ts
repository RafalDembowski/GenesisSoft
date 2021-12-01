import {  makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Product } from "../models/product";

export default class ProductStore {

    products: Product[] = [];
    loading = false;
    orderBy: string = '';

    constructor(){
        makeAutoObservable(this)
    }

    get axiosParams() {
        const params = new URLSearchParams();

        if(this.orderBy !== ''){
            params.append('OrderBy', this.orderBy);
        }
        
        return params;
    }

    getProducts = async () => {
        this.loading = true;
        try{
            const products = await agent.Products.test(this.axiosParams);

            runInAction(() => {
                this.products = products;
                this.loading = false;
            })

        }catch(error){
            console.log(error)
            runInAction(() => this.loading = false)
        }
    }

    setOrderBy = (orderby: string) => {
        runInAction(() => {
            this.orderBy = orderby;
            this.getProducts();
        })
    }

}