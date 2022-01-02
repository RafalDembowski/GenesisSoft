import {  makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Pagination, PagingParams } from "../models/pagination";
import { Product } from "../models/product";

export default class ProductStore {

    products: Product[] = [];
    product: Product | undefined = undefined;
    loadingProduct = false;
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
        this.loadingProduct = true;
        try{

            const result = await agent.Products.list(this.axiosParams);

            runInAction(() => {
                this.products = result.data;
                this.pagination = result.pagination;
                this.loadingProduct = false;
            })

        }catch(error){
            console.log(error)
            runInAction(() => this.loadingProduct = false)
        }
    }

    getProduct = async (id: string) => {
        let product = this.getProductById(id);

        if(product){
            this.product = product;
            return product;
        }
        else{
            this.loadingProduct = true;
            try{
                product = await agent.Products.get(id);
                runInAction(() => {
                    this.product = product;
                    this.loadingProduct = false;
                })
                return product;
            }catch(error){
                console.log(error)
                runInAction(() => this.loadingProduct = false)
            }
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

    private getProductById = (id: string) => {
        return this.products.find(p => p.id === id);
    }
}