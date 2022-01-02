import { createContext, useContext } from "react";
import ProductStore from "./productStore";
import ProductCategoryStore from "./productCategoryStore";

interface Store {
    productStore : ProductStore,
    productCategoryStore : ProductCategoryStore
}

export const store: Store = {
    productStore : new ProductStore(),
    productCategoryStore : new ProductCategoryStore()
}

export const StoreContext = createContext(store);

export function useStore(){
    return useContext(StoreContext);
}  