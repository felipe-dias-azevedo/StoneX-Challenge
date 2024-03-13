"use client";
import List from "@mui/material/List";
import Stack from "@mui/material/Stack";
import HeaderBar from "@/components/HeaderBar";
import { useEffect, useState } from "react";
import ProductCard from "@/components/ProductCard";
import { Dialog, ListItem, Modal } from "@mui/material";
import FormProductCard from "@/components/FormProductCard";
import { getProducts, postProduct } from "@/services/productService";
import { ProductModel, ProductViewModel } from "@/models/product";
import { useSnackbar } from "notistack";

export default function Home() {
  const { enqueueSnackbar } = useSnackbar();

  const [products, setProducts] = useState<ProductModel[]>([]);
  const [modalOpen, setModalOpen] = useState(false);

  const getProductsExternal = () => {
    getProducts()
      .then((data) => {
        setProducts(data);
        console.log(data);
      })
      .catch((err) => {
        enqueueSnackbar("Error at getting products.");
        console.error(err);
      });
  };

  useEffect(() => {
    getProductsExternal();
  }, [setProducts]);

  const onSubmit = (data: ProductViewModel) => {
    postProduct(data)
      .then(() => {
        getProductsExternal();
        setModalOpen(false);
      })
      .catch((err) => {
        enqueueSnackbar("Error at posting a new product.");
        console.error(err);
      });
  };

  return (
    <main>
      <Stack>
        <HeaderBar newButtonCallback={() => setModalOpen(true)} />
        <List>
          {products.map((p) => (
            <ListItem key={p.id}>
              <ProductCard
                id={p.id}
                name={p.name}
                stockKeepingUnit={p.stockKeepingUnit}
                price={p.price}
                stockCount={p.stockCount}
                updateViewCallback={getProductsExternal}
              />
            </ListItem>
          ))}
        </List>

        <Dialog open={modalOpen} onClose={() => setModalOpen(false)}>
          <FormProductCard
            title="New Product"
            cancelCallback={() => setModalOpen(false)}
            submitCallback={onSubmit}
          />
        </Dialog>
      </Stack>
    </main>
  );
}
