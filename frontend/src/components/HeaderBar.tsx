import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import IconButton from "@mui/material/IconButton";
import AddIcon from "@mui/icons-material/Add";

type HeaderBarProps = {
  newButtonCallback: () => void;
};

export default function HeaderBar({ newButtonCallback }: HeaderBarProps) {
  return (
    <AppBar position="static">
      <Toolbar>
        <Typography variant="h5" component="div" sx={{ flexGrow: 1 }}>
          Products
        </Typography>
        <Button
          variant="outlined"
          color="inherit"
          endIcon={<AddIcon />}
          onClick={newButtonCallback}
        >
          New
        </Button>
      </Toolbar>
    </AppBar>
  );
}
