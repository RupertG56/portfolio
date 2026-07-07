import { Icon } from "@mui/material";
import logoImg from "../assets/logo.png";

export default function IconLogo(props: any) {
    return (
        <Icon {...props}>
            <img src={logoImg} alt="Portfolio logo representing professional identity and brand" />
        </Icon>
    );
}