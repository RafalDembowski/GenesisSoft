import axios, { AxiosError, AxiosResponse } from 'axios'
import { PaginatedResult } from '../models/pagination';
import { Product } from '../models/product';

axios.defaults.baseURL = 'https://localhost:44330'

axios.interceptors.response.use(async response => {

    let pagination = response.headers['pagination']
    if(pagination){
        response.data = new PaginatedResult(response.data, JSON.parse(pagination));
        return response as AxiosResponse<PaginatedResult<any>>
    }

    return response;
}, (error: AxiosError) => {
    return Promise.reject(error);
})

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody)
}

const Products = {
    list: () => requests.get<Product[]>('api/Products'),
    test: (params: URLSearchParams) => axios.get<PaginatedResult<Product[]>>('/api/Products', { params }).then(responseBody),
}

const agent = {
    Products
}

export default agent;