import {  makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Pagination, PagingParams } from "../models/pagination";
import { Product } from "../models/product";

export default class ProductStore {

    products: Product[] = [];
    loading = false;
    orderBy: string = '';
    pagination: Pagination | null = null;
    pagingParams = new PagingParams();
    
    constructor(){
        makeAutoObservable(this)
    }

    get axiosParams() {
        const params = new URLSearchParams();

        if(this.orderBy !== ''){
            params.append('OrderBy', this.orderBy);
        }

        params.append('PageNumber' , this.pagingParams.currentPage.toString());
        params.append('PageSize' , this.pagingParams.pageSize.toString());
       
        return params;
    }

    getProducts = async () => {
        this.loading = true;
        try{

            const result = await agent.Products.test(this.axiosParams);

            runInAction(() => {
                this.products = result.data;
                this.pagination = result.pagination;
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

    setPagingParams = (pagingParams: PagingParams) => {
        runInAction(() => {
            this.pagingParams = pagingParams;
            this.getProducts();
        })
    }

}