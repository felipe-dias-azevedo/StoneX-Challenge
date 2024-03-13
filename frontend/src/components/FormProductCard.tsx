"use client";
import { zodResolver } from "@hookform/resolvers/zod";
import Card from "@mui/material/Card";
import Typography from "@mui/material/Typography";
import TextField from "@mui/material/TextField";
import Divider from "@mui/material/Divider";
import { useForm, Controller, SubmitHandler } from "react-hook-form";
import { z } from "zod";
import {
  Button,
  DialogActions,
  DialogContent,
  List,
  ListItem,
  Stack,
} from "@mui/material";
import FormErrorMessage from "./FormErrorMessage";
import { ProductViewModel } from "@/models/product";
import InputProduct from "./InputProduct";
import { useEffect } from "react";

type FormProductCardProps = {
  title: string;
  oldProduct?: ProductViewModel;
  cancelCallback: () => void;
  submitCallback: (product: ProductViewModel) => void;
};

const schema = z
  .object({
    productName: z.string().min(2),
    stockKeepingUnit: z.string().min(6).max(12),
    price: z.preprocess(
      (a) => parseInt(z.string().parse(a), 10),
      z.number().positive()
    ),
    stockCount: z.preprocess(
      (a) => parseInt(z.string().parse(a), 10),
      z.number().positive()
    ),
  })
  .required();

type Schema = z.infer<typeof schema>;

export default function FormProductCard({
  title,
  oldProduct,
  cancelCallback,
  submitCallback,
}: FormProductCardProps) {
  const {
    setValue,
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<Schema>({
    mode: "all",
    resolver: zodResolver(schema),
    values: oldProduct
  });

  // useEffect(() => {
  //   console.log("TEST")
  //   if (oldProduct) {
  //     setValue("productName", oldProduct.productName, {shouldDirty: true});
  //     setValue("stockKeepingUnit", oldProduct.stockKeepingUnit, {shouldDirty: true});
  //     setValue("price", oldProduct.price, {shouldDirty: true});
  //     setValue("stockCount", oldProduct.stockCount, {shouldDirty: true});
  //   }
  // }, []);

  const onSubmit: SubmitHandler<ProductViewModel> = (data) => {
    console.log(data);
    submitCallback(data);
  };

  return (
    <>
      <DialogContent sx={{ paddingLeft: 4, paddingRight: 4 }}>
        <Typography variant="h5" sx={{ flexGrow: 1, marginBottom: 4 }}>
          {title}
        </Typography>

        <form id="product-card-form" onSubmit={handleSubmit(onSubmit)}>
          <Stack>
            <InputProduct
              title="Product Name"
              type="text"
              error={errors.productName}
              register={register}
              registerName="productName"
            />

            <InputProduct
              title="SKU"
              type="text"
              error={errors.stockKeepingUnit}
              register={register}
              registerName="stockKeepingUnit"
            />

            <InputProduct
              title="Price"
              type="number"
              error={errors.price}
              register={register}
              registerName="price"
            />

            <InputProduct
              title="Stock"
              type="number"
              error={errors.stockCount}
              register={register}
              registerName="stockCount"
            />
          </Stack>
        </form>
      </DialogContent>

      <DialogActions sx={{ paddingBottom: 4, paddingRight: 4 }}>
        <Button onClick={cancelCallback}>Cancel</Button>
        <Button form="product-card-form" type="submit" variant="contained">
          Save
        </Button>
      </DialogActions>
    </>
  );
}
