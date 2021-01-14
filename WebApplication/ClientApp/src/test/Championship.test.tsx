import React from 'react';
import { act, render, screen } from '@testing-library/react';
import Championship from '../components/Championship';
import Movie from '../api/movie';
import messages from '../locale/locale';
import { FetchResponse, mockFetchWith } from './mock';

const routerMock = {
    useLocation: () => ({
        state: {
            ids: ["t123", "t1234"]
        }
    }),
    useHistory: () => ({

    })
}

jest.mock("react-router-dom", () => routerMock);

var movies: Movie[] = [{
    id: "ts1",
    titulo: "movie1",
    ano: 1984,
    nota: 1.3
}, {
    id: "ts2",
    titulo: "movie2",
    ano: 2015,
    nota: 1.5
}];

const mocks: Map<string, any> = new Map<string, FetchResponse<Movie[]>>([
    ['api/v1/championships', {
        status: 200,
        body: movies
    }]
]);

it("renders components with two movies", async () => {

    mockFetchWith(mocks);

    await act(async () => {
        render(<Championship />);
    });

    expect(document.querySelectorAll('.movie-container').length).toEqual(2);
    expect(screen.getByText('movie1')).toBeInTheDocument();
    expect(screen.getByText('movie2')).toBeInTheDocument();
    expect(screen.getByText(messages.championship.newRound)).toBeInTheDocument();
});