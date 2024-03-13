import ProductService from "@/services/productService";
import { createContext } from "react";

const productService = new ProductService();

export const ProductContext = createContext(productService);

export function ProductProvider({ children }: any) {
  return (
    <ProductContext.Provider value={productService}>
      {children}
    </ProductContext.Provider>
  );
}
