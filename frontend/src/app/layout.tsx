"use client";
import type { Metadata } from "next";
import { Inter } from "next/font/google";
import { AppRouterCacheProvider } from "@mui/material-nextjs/v13-appRouter";
import { ThemeProvider } from "@mui/material/styles";
import theme from "../theme";
import "./globals.css";
import { SnackbarProvider } from "notistack";
import { ProductProvider } from "@/contexts/ProductContext";

const inter = Inter({ subsets: ["latin"] });

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <ProductProvider>
          <AppRouterCacheProvider>
            <ThemeProvider theme={theme}>
              <SnackbarProvider maxSnack={5}>{children}</SnackbarProvider>
            </ThemeProvider>
          </AppRouterCacheProvider>
        </ProductProvider>
      </body>
    </html>
  );
}
