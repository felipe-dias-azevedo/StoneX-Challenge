import { Stack, TextField } from "@mui/material";
import FormErrorMessage from "./FormErrorMessage";
import { FieldError } from "react-hook-form";

type InputProductProps = {
    title: string;
    type: string; 
    error?: FieldError;
    register: any;
    registerName: string;
};

export default function InputProduct({ title, type, error, register, registerName }: InputProductProps) {
  return (
    <Stack sx={{ marginBottom: 2 }}>
      <TextField
        type={type}
        error={!!error}
        label={title}
        variant="outlined"
        sx={{ flexGrow: 1 }}
        {...register(registerName)}
      />
      <FormErrorMessage error={error} />
    </Stack>
  );
}
