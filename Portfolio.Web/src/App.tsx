import {
  AppBar,
  Box,
  Button,
  Card,
  CardActions,
  CardContent,
  Container,
  Divider,
  IconButton,
  Stack,
  Toolbar,
  Typography,
  Chip,
  Grid,
  Link,
} from "@mui/material";
import GitHubIcon from "@mui/icons-material/GitHub";
import LinkedInIcon from "@mui/icons-material/LinkedIn";
import EmailIcon from "@mui/icons-material/Email";

const projects = [
  {
    title: "Homelab Platform",
    desc: "Rocky Linux + ZFS + Podman quadlets + systemd-user services. Automated boot + sane ops.",
    tags: ["Linux", "Podman", "systemd", "ZFS"],
    href: "#",
  },
  {
    title: "Media Pipeline",
    desc: "FFmpeg/HandBrake workflow for consistent naming, codec policies, and Plex compatibility.",
    tags: ["FFmpeg", "Plex", "Automation"],
    href: "#",
  },
  {
    title: "Backend Service",
    desc: ".NET API with clean DI, observability, and deployment-ready container image.",
    tags: [".NET", "API", "Containers"],
    href: "#",
  },
];

const social = {
  github: "https://github.com/rupertg56",
  linkedin: "https://www.linkedin.com/in/ryan-jones-519b9919/",
  mailto: "mailto:rupertg56@gmail.com",
  email: "rupertg56@gmail.com",
}

function TopNav() {
  return (
    <AppBar position="sticky" elevation={0} color="transparent">
      <Toolbar sx={{ backdropFilter: "blur(10px)" }}>
        <Typography variant="h6" sx={{ fontWeight: 800, flexGrow: 1 }}>
          Ryan Jones
        </Typography>

        <Stack direction="row" spacing={1} alignItems="center">
          <Button href="#projects" color="inherit" variant="text">
            Projects
          </Button>
          <Button href="#contact" color="inherit" variant="text">
            Contact
          </Button>
          <Divider orientation="vertical" flexItem sx={{ mx: 1 }} />
          <IconButton aria-label="github" component="a" href={social.github} target="_blank">
            <GitHubIcon />
          </IconButton>
          <IconButton aria-label="linkedin" component="a" href={social.linkedin} target="_blank">
            <LinkedInIcon />
          </IconButton>
        </Stack>
      </Toolbar>
    </AppBar>
  );
}

function Hero() {
  return (
    <Box sx={{ py: { xs: 6, md: 10 } }}>
      <Container maxWidth="md">
        <Stack spacing={2}>
          <Typography variant="h4">
            Infra-heavy software engineer building practical systems.
          </Typography>
          <Typography variant="h6" sx={{ opacity: 0.85 }}>
            I ship backend services, run a serious homelab, and like clean automation: Linux, containers,
            systemd, storage, and sane production patterns.
          </Typography>
          <Stack direction={{ xs: "column", sm: "row" }} spacing={2} sx={{ pt: 2 }}>
            <Button size="large" href="#projects">
              View projects
            </Button>
            <Button size="large" variant="outlined" href="#contact">
              Get in touch
            </Button>
          </Stack>
          <Stack direction="row" spacing={1} sx={{ pt: 2, flexWrap: "wrap" }}>
            {["Linux", "Containers", ".NET", "Networking", "Automation"].map((t) => (
              <Chip key={t} label={t} />
            ))}
          </Stack>
        </Stack>
      </Container>
    </Box>
  );
}

function Projects() {
  return (
    <Box id="projects" sx={{ py: { xs: 6, md: 8 } }}>
      <Container maxWidth="md">
        <Stack spacing={3}>
          <Typography variant="h4" sx={{ fontWeight: 800 }}>
            Projects
          </Typography>

          <Grid container spacing={2}>
            {projects.map((p) => (
              <Grid key={p.title}>
                <Card sx={{ height: "100%" }}>
                  <CardContent>
                    <Typography variant="h6" sx={{ fontWeight: 800 }}>
                      {p.title}
                    </Typography>
                    <Typography sx={{ opacity: 0.85, mt: 1 }}>
                      {p.desc}
                    </Typography>
                    <Stack direction="row" spacing={1} sx={{ mt: 2, flexWrap: "wrap" }}>
                      {p.tags.map((t) => (
                        <Chip key={t} label={t} size="small" variant="outlined" />
                      ))}
                    </Stack>
                  </CardContent>
                  <CardActions sx={{ px: 2, pb: 2 }}>
                    <Button href={p.href} variant="text" color="secondary">
                      Details
                    </Button>
                  </CardActions>
                </Card>
              </Grid>
            ))}
          </Grid>
        </Stack>
      </Container>
    </Box>
  );
}

function Contact() {
  return (
    <Box id="contact" sx={{ py: { xs: 6, md: 8 } }}>
      <Container maxWidth="md">
        <Card>
          <CardContent>
            <Typography variant="h4" sx={{ fontWeight: 800 }}>
              Contact
            </Typography>
            <Typography sx={{ opacity: 0.85, mt: 1 }}>
              Email works best. If you prefer, link to a Calendly / resume PDF here too.
            </Typography>

            <Stack direction={{ xs: "column", sm: "row" }} spacing={2} sx={{ mt: 3 }}>
              <Button startIcon={<EmailIcon />} component="a" href={social.mailto} variant="contained">
                Email me
              </Button>
              <Button startIcon={<GitHubIcon />} component="a" href={social.github} target="_blank" variant="outlined">
                GitHub
              </Button>
              <Button startIcon={<LinkedInIcon />} component="a" href={social.linkedin} target="_blank" variant="outlined">
                LinkedIn
              </Button>
            </Stack>

            <Typography sx={{ mt: 3, opacity: 0.7 }}>
              Or just:{" "}
              <Link href={social.mailto} underline="hover">
                {social.email}
              </Link>
            </Typography>
          </CardContent>
        </Card>
      </Container>
    </Box>
  );
}

function Footer() {
  return (
    <Box sx={{ py: 4, opacity: 0.7 }}>
      <Container maxWidth="md">
        <Divider sx={{ mb: 2 }} />
        <Typography variant="body2">
          © {new Date().getFullYear()} Ryan Jones
        </Typography>
      </Container>
    </Box>
  );
}

export default function App() {
  return (
    <Box>
      <TopNav />
      <Hero />
      <Projects />
      <Contact />
      <Footer />
    </Box>
  );
}
