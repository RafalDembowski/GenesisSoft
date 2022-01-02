export interface Product {
    id: string;
    name: string;
    categoryId: string;
    categoryName: string;
    producerName: string;
    createdAt: Date | null;
    createdBy: string;
    updatedAt: Date | null;
    updatedBy: string;
}

export class ProductFormInitialValue {
    id?: string = undefined;
    name: string = "";
    categoryId: string = "";
    categoryName: string = "";
    producerName: string = "";
    createdAt: Date | null = null;
    createdBy: string = "";
    updatedAt: Date | null = null;
    updatedBy: string = "";

    constructor(product?: any){
        if(product){
            this.id = product.id;
            this.name = product.name;
            this.categoryId = product.categoryId;
            this.categoryName = product.categoryName;
            this.producerName = product.producerName;
            this.createdAt = product.createdAt;
            this.createdBy = product.createdBy;
            this.updatedAt = product.updatedAt;
            this.updatedBy = product.updatedBy;
        }
    }

}