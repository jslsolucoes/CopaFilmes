import styled from 'styled-components';

export const Container = styled.div`
   

   color: #285d96;

   .movie-container {
        display: flex;
        margin: 10px 0px;
        height: 50px;
   }

   .movie-classification {
        width: 50px;
        font-size: 1.5em;
        background-color: #285d96;
        color: #fff;
        display: flex;
        align-items: center;
        justify-content: center;
   }

   .movie-details {
        flex: 1; 
        background-color: #fff;
        display: flex;
        align-items: center;
        border: 1px solid #285d96;
        border-radius: 2px;
        border-top-left-radius: 0;
        border-bottom-left-radius: 0;
   }

   .movie-details > span {
        margin-left: 5px;
   }

`;