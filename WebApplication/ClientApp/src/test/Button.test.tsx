import React from 'react';
import { render, screen } from '@testing-library/react';
import Button from '../components/Button';

test('renders a button disabled', () => {
    render(<Button label="button1" disabled={true} />);
    const buttonElement = screen.getByText("button1")
    expect(buttonElement).toBeInTheDocument();
    expect(buttonElement).toBeDisabled();
});



test('renders a button', () => {
    render(<Button label="button2" />);
    const buttonElement = screen.getByText("button2")
    expect(buttonElement).toBeInTheDocument();
    expect(buttonElement).not.toBeDisabled();
});
