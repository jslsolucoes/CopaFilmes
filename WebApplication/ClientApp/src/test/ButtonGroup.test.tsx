import React from 'react';
import { render, screen } from '@testing-library/react';
import ButtonGroup from '../components/ButtonGroup';
import Button from '../components/Button';

test('renders a button group with button', () => {
    render(<ButtonGroup><Button label="button1" /></ButtonGroup>);
    const buttonElement = screen.getByText("button1")
    expect(buttonElement).toBeInTheDocument();
});


