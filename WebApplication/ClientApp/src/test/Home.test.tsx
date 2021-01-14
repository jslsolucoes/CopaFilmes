import React from 'react';
import { act, render, screen } from '@testing-library/react';
import Movie from '../api/movie';
import Config from '../api/config';
import { FetchResponse, mockFetchWith } from './mock';
import Home from '../components/Home';

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

var config: Config = {
    maxMovies: 8
}

const mocks: Map<string, any> = new Map<string, FetchResponse<Movie[] | Config>>([
    ['api/v1/movies', {
        status: 200,
        body: movies
    }],
    ['api/v1/configs', {
        status: 200,
        body: config
    }]
]);

it("renders components with two movies", async () => {

    mockFetchWith(mocks);

    await act(async () => {
        render(<Home />);
    });

    expect(document.querySelectorAll('.card').length).toEqual(2);
    expect(screen.getByText('movie1')).toBeInTheDocument();
    expect(screen.getByText('movie2')).toBeInTheDocument();
});