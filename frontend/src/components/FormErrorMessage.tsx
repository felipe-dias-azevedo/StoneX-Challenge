import { Typography } from "@mui/material";
import { FieldError } from "react-hook-form";

type FormErrorMessageProps = {
  error?: FieldError;
};

export default function FormErrorMessage({ error }: FormErrorMessageProps) {
  return (
    <>
      {error && (
        <Typography color="#D32F2F">{error.message?.toString()}</Typography>
      )}
    </>
  );
}
