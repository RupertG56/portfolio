import { createTheme, type ThemeOptions } from "@mui/material/styles";

export const themeOptions: ThemeOptions = {
  palette: {
    mode: "dark",

    primary: {
      main: "#4FC3F7", // cyan-blue accent
      light: "#81D4FA",
      dark: "#0288D1",
    },

    secondary: {
      main: "#7C4DFF", // violet highlight
    },

    background: {
      default: "#020617", // near-black blue
      paper: "#0B1026",
    },

    text: {
      primary: "#E6F1FF",
      secondary: "#8FB3D9",
    },

    divider: "rgba(255,255,255,0.08)",
  },

  shape: {
    borderRadius: 10,
  },

  typography: {
    fontFamily: [
      "Inter",
      "JetBrains Mono",
      "system-ui",
      "sans-serif",
    ].join(","),

    h1: { fontWeight: 800 },
    h2: { fontWeight: 800, letterSpacing: -0.5 },
    h3: { fontWeight: 700 },
    h4: { fontWeight: 700 },

    body1: { lineHeight: 1.7 },
  },

  components: {
    MuiButton: {
      defaultProps: {
        disableElevation: true,
      },
      styleOverrides: {
        root: {
          textTransform: "none",
          fontWeight: 600,
          borderRadius: 10,
          padding: "8px 18px",
        },
        containedPrimary: {
          background: "linear-gradient(135deg, #4FC3F7, #7C4DFF)",
        },
      },
    },

    MuiCard: {
      styleOverrides: {
        root: {
          border: "1px solid rgba(255,255,255,0.08)",
          backdropFilter: "blur(6px)",
        },
      },
    },

    MuiAppBar: {
      styleOverrides: {
        root: {
          background: "rgba(2,6,23,0.85)",
          backdropFilter: "blur(10px)",
        },
      },
    },

    MuiChip: {
      styleOverrides: {
        root: {
          borderRadius: 6,
          fontWeight: 600,
        },
      },
    },
  },
};

export const theme = createTheme(themeOptions);
