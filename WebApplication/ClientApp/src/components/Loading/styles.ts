import styled from 'styled-components';

export const Container = styled.div`

    div.overlay {
        display: flex;
        align-items: center;
        justify-content: center;
        position: absolute;
        width: 100%;
        height: 100%;
        background: rgba(0,0,0,.4);
        z-index: 2000;
        top:0;
        left:0;
    }

    div.loading {
        width: 60px;
        height: 60px;
        background-color: #fff;
        padding: 10px;
        border-radius: .25rem;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    div.loading-indicator {
        width: 60px;
        height: 60px;
    }

    .square {
        width: 33%;
        height: 33%;
        background-color: #285d96;
        float: left;
        animation: cubeGridScaleDelay 1.3s infinite ease-in-out;
    }

    .animation-delay-0s {
        animation-delay: 0s; 
    }
    .animation-delay-02s {
       animation-delay: 0.2s; 
    }
    .animation-delay-03s {
       animation-delay: 0.3s; 
    }
    .animation-delay-04s {
       animation-delay: 0.4s; 
    }
    
    @keyframes cubeGridScaleDelay {
        0%, 70%, 100% {
                    transform: scale3D(1, 1, 1);
        } 35% {
            -webkit-transform: scale3D(0, 0, 1);
                    transform: scale3D(0, 0, 1);
        } 
    }

`;