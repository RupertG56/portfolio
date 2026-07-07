import { Box } from "@mui/material";
import IconLogo from "./content/IconLogo";

export default function Header() {
    return (
        <Box component="header" sx={{ display: "flex", alignItems: "center", gap: 2, mb: 4 }}>
          <IconLogo sx={{ width: '128px', height: '128px' }} />
          <span style={{ verticalAlign: 'middle' }}>Ryan K Jones</span>
        </Box>
    );
}