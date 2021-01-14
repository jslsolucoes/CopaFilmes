import React, { useState, useEffect, useCallback } from 'react';
import { Container } from './styles';
import { useHistory } from "react-router-dom";
import Movie from '../../api/movie';
import Header from '../Header';
import Button from '../Button';
import Loading from '../Loading';
import ButtonGroup from '../ButtonGroup';
import service from '../../api/service';
import messages from '../../locale/locale';
import Config from '../../api/config';
import error from '../Error';

const Home: React.FC = () => {

    const history = useHistory();
    const [movies, setMovies] = useState<Movie[]>([]);
    const [configs, setConfigs] = useState<Config>({
        maxMovies: 8
    });
    const [ids, setIds] = useState<string[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);

    const fetchMovies = useCallback(async () => {
        try {
            const movies = await service.movies.allMovies();
            setMovies(movies);
        } catch (err) {
            error(messages.api.error.title, messages.format(messages.api.error.message));
        } finally {
            setIsLoading(false);
        }
    }, []);

    const fetchConfigs = useCallback(async () => {
        try {
            const configs = await service.configs.allConfigs();
            setConfigs(configs);
        } catch (err) {
            error(messages.api.error.title, messages.format(messages.api.error.message));
        }
    }, []);

    const init = useCallback(async () => {
        try {
            await Promise.all([fetchMovies(), fetchConfigs()]);
        } catch (err) {
            error(messages.api.error.title, messages.format(messages.api.error.message));
        } finally {
            setIsLoading(false);
        }
    }, [fetchMovies, fetchConfigs]);

    useEffect(() => {
        init();
    }, [init]);


    const classify = () => {
        history.push('/classify', { ids });
    }

    const addOrRemove = (movie: Movie, event: React.MouseEvent<HTMLDivElement, MouseEvent>) => {
        if (ids.includes(movie.id)) {
            remove(movie);
        } else {
            add(movie, event);
        }
    }

    const add = (movie: Movie, event: React.MouseEvent<HTMLInputElement, MouseEvent> | React.MouseEvent<HTMLDivElement, MouseEvent>) => {
        const maxMovies = configs.maxMovies;
        if (ids.length === maxMovies) {
            event.preventDefault();
            error(messages.home.errors.title, messages.format(messages.home.errors.maxSizeReached, maxMovies))
            return;
        }
        setIds([movie.id, ...ids]);
    }

    const remove = (movie: Movie) => {
        setIds(ids.filter(id => id !== movie.id));
    }

    const hasMovies = () => {
        return movies.length > 0;
    }

    const isSelected = (movie: Movie) => {
        return ids.includes(movie.id)
    }

    return (
        <Container>
            <Loading visible={isLoading} />
            <Header title={messages.home.header.title} message={messages.format(messages.home.header.message, configs.maxMovies)} />
            <ButtonGroup>
                <Button label={messages.format(messages.home.buttons.classify, ids.length)} onClick={classify} disabled={ids.length < 8}></Button>
            </ButtonGroup>
            { !hasMovies() && (<span>{messages.home.loading.movies}</span>)}
            { hasMovies() && (<div>{messages.format(messages.home.selected, ids.length, configs.maxMovies)}</div>)}
            <div className="card-container">
                {
                    movies.map(movie => {
                        return (
                            <div key={movie.id} className="card-col card-col-4 card-col-sm-12" onClick={event => addOrRemove(movie, event)} >
                                <div className={`card ${isSelected(movie) ? 'card-selected' : ''}`}>
                                    <div>
                                        <input aria-label={movie.titulo} type="checkbox" checked={isSelected(movie)} onChange={event => { }} onClick={event => event.currentTarget.checked ? add(movie, event) : remove(movie)} />
                                    </div>
                                    <div className="card-body">
                                        <span>{movie.titulo}</span>
                                        <small>{movie.ano}</small>
                                    </div>
                                </div>
                            </div>
                        )
                    })
                }
            </div>
        </Container>
    );
};

export default Home;