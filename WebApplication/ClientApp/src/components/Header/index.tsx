import React from 'react';
import messages from '../../locale/locale';
import { Container } from './styles';


interface HeaderProps {
    title: string;
    message: string;
}

const Header: React.FC<HeaderProps> = ({ title, message }) => {


    return (
        <Container>
            <h4 className="title-primary">{messages.header.title}</h4>
            <h2 className="title-secondary">{title}</h2>
            <hr className="divisor" />
            <small className="message">{message}</small>
        </Container>
    );
};

export default Header;