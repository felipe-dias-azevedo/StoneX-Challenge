"use client";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import { useContext, useState } from "react";
import FormProductCard from "./FormProductCard";
import { Dialog } from "@mui/material";
import { ProductViewModel } from "@/models/product";
import { useSnackbar } from "notistack";
import { ProductContext } from "@/contexts/ProductContext";

type ProductCardProps = {
  id: string;
  name: string;
  stockKeepingUnit: string;
  price: number;
  stockCount: number;
  updateViewCallback: () => void;
};

export default function ProductCard({
  id,
  name,
  stockKeepingUnit,
  price,
  stockCount,
  updateViewCallback,
}: ProductCardProps) {
  const { enqueueSnackbar } = useSnackbar();
  const productService = useContext(ProductContext);

  const [modalOpen, setModalOpen] = useState(false);

  const onSubmit = (data: ProductViewModel) => {
    productService.updateProduct(id, data)
      .then(() => {
        updateViewCallback();
        setModalOpen(false);
      })
      .catch((err) => {
        enqueueSnackbar("Error at updating an existing product.");
        console.error(err);
      });
  };

  const onDelete = () => {
    productService.deleteProduct(id)
      .then(() => {
        updateViewCallback();
      })
      .catch((err) => {
        enqueueSnackbar("Error at deleting a product.");
        console.error(err);
      });
  };

  return (
    <>
      <Card variant="outlined" sx={{ flexGrow: 1 }}>
        <CardContent>
          <Typography variant="caption" color="text.secondary" gutterBottom>
            SKU: {stockKeepingUnit}
          </Typography>
          <Typography variant="h4" component="div">
            {name}
          </Typography>
          <Typography variant="body1" color="text.secondary">
            Stock: {stockCount}
          </Typography>
          <Typography variant="h6">$ {price}</Typography>
        </CardContent>
        <CardActions>
          <Button
            variant="outlined"
            color="primary"
            endIcon={<EditIcon />}
            onClick={() => setModalOpen(true)}
          >
            Edit
          </Button>
          <Button
            variant="outlined"
            color="error"
            endIcon={<DeleteIcon />}
            onClick={onDelete}
          >
            Remove
          </Button>
        </CardActions>
      </Card>

      <Dialog open={modalOpen} onClose={() => setModalOpen(false)}>
        <FormProductCard
          title="Edit Product"
          oldProduct={{
            productName: name,
            stockKeepingUnit,
            price,
            stockCount,
          }}
          cancelCallback={() => setModalOpen(false)}
          submitCallback={onSubmit}
        />
      </Dialog>
    </>
  );
}
