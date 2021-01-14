import React, { memo } from 'react';
import { Container } from './styles';


interface LoadingProps {
    visible: boolean;
}

const Loading: React.FC<LoadingProps> = ({ visible }) => {
    if (visible) {
        return (
            <Container>
                <div className="overlay">
                    <div className="loading">
                        <div className="loading-indicator">
                            <div className="square animation-delay-02s"></div>
                            <div className="square animation-delay-03s"></div>
                            <div className="square animation-delay-04s"></div>
                            <div className="square animation-delay-01s"></div>
                            <div className="square animation-delay-02s"></div>
                            <div className="square animation-delay-03s"></div>
                            <div className="square animation-delay-0s"></div>
                            <div className="square animation-delay-01s"></div>
                            <div className="square animation-delay-02s"></div>
                        </div>
                    </div>
                </div>
            </Container>
        );
    }
    return <></>;
};

export default memo(Loading);