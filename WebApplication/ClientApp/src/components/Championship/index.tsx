import React, { useState, useEffect, useCallback } from 'react';
import { Container } from './styles';
import Movie from '../../api/movie';
import { useHistory, useLocation } from "react-router-dom";
import Header from '../Header';
import Button from '../Button';
import ButtonGroup from '../ButtonGroup';
import Loading from '../Loading';
import service from '../../api/service';
import messages from '../../locale/locale';
import error from '../Error';


interface LocationParams {
    ids: string[]
}

const Championship: React.FC = () => {

    const history = useHistory();
    const [movies, setMovies] = useState<Movie[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const { state } = useLocation<LocationParams>();

    const goToHome = () => {
        history.push('/', { ids: [] });
    }

    const fetchClassify = useCallback(async (ids: string[]) => {
        try {
            const movies = await service.championship.createChampionship(ids);
            setMovies(movies);
        } catch (err) {
            error(messages.api.error.title, messages.api.error.message);
        } finally {
            setIsLoading(false);
        }
    }, []);

    useEffect(() => {
        fetchClassify(state.ids);
    }, [fetchClassify, state.ids]);

    const { newRound, loading, title, message } = messages.championship;

    return (
        <Container>
            <Loading visible={isLoading} />
            <Header title={title} message={message} />
            <ButtonGroup>
                <Button label={newRound} onClick={goToHome}></Button>
            </ButtonGroup>
            { movies.length === 0 && (<span>{loading}</span>)}
            {
                movies.map((movie, index) => {
                    return (
                        <div className="movie-container" key={movie.id}>
                            <div className="movie-classification">
                                <span>{index + 1}º</span>
                            </div>
                            <div className="movie-details">
                                <span>{movie.titulo}</span>
                            </div>
                        </div>
                    )
                })
            }
        </Container>
    );
};

export default Championship;