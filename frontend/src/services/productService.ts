import { ProductViewModel } from "@/models/product";
import api from "./api";

export async function getProducts() {
    const result = await api.get("v1/product");
    return result.data;
}

export async function postProduct(product: ProductViewModel) {
    const result = await api.post("v1/product", {
        ...product,
        name: product.productName,        
    });
    return result.data;
}

export async function updateProduct(id: string, product: ProductViewModel) {
    const result = await api.put(`v1/product/${id}`, {
        ...product,
        name: product.productName,
    });
    return result.data;
}

export async function deleteProduct(id: string) {
    const result = await api.delete(`v1/product/${id}`);
    return result.data;
}