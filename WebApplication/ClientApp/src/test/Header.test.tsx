import React from 'react';
import { render, screen } from '@testing-library/react';
import Header from '../components/Header';
import messages from '../locale/locale';

test('renders a header', () => {
    const title = "titl1";
    const message = "message1";
    render(<Header title={title} message={message} />);
    const titlePage = screen.getByText(messages.header.title);
    const titleElement = screen.getByText(title);
    const messageElement = screen.getByText(message);
    expect(titlePage).toBeInTheDocument();
    expect(titleElement).toBeInTheDocument();
    expect(messageElement).toBeInTheDocument();
});