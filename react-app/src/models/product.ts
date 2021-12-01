export interface Product {
    id: string;
    name: string;
    categoryName: string;
    producerName: string;
    createdAt: Date | null;
    createdBy: string;
    updatedAt: Date | null;
    updatedBy: string;
}