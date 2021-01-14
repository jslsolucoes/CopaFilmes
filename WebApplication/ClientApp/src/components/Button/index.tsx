import React from 'react';
import { Container } from './styles';


interface ButtonProps {
    label: string;
    onClick?: (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => void;
    disabled?: boolean;
}

const Button: React.FC<ButtonProps> = ({ label, disabled, onClick }) => {

    const handleOnClick = (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        if (onClick) {
            onClick(event);
        }
    }

    return (
        <Container>
            <button type="button" onClick={handleOnClick} disabled={disabled}>
                {label}
            </button>
        </Container>
    );
};

export default Button;