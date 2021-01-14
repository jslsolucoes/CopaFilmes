import React from 'react';
import { render } from '@testing-library/react';
import Loading from '../components/Loading';

test('renders a visible loading', () => {
    const { container } = render(<Loading visible={true} />);
    const squares = container.getElementsByClassName('square');
    expect(squares.length).toEqual(9);
});

test('renders an not visible loading', () => {
    const { container } = render(<Loading visible={false} />);
    const overlay = container.getElementsByClassName('overlay');
    expect(overlay.length).toEqual(0);
});
