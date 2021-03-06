import React from 'react';
import { Container } from './styles';


const ButtonGroup: React.FC = ({ children }) => {

    return (
        <Container>
            {children}
        </Container>
    );
};

export default ButtonGroup;