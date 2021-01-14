import styled from 'styled-components';

export const Container = styled.div`
   color: #285d96;
   
   .card-container {
        display: flex;
        flex-wrap: wrap;
    }

    .card-container > * {
        flex-shrink: 0;
        width: 100%;
        max-width: 100%;
    }

    .card-col {
        flex: 1 0 0%;
    }

    .card-col-4 {
        flex: 0 0 auto;
        width: 25%;
    }

    @media (max-width:768px) {
        .card-col-sm-12 {
            flex: 0 0 auto;
            width: 100%;
        }
   }

   .card {
        height: 50px;
        background-color: #fff;
        border: 1px solid #285d96;
        border-radius: 3px;
        padding: 15px;
        margin: 5px;
        display: flex;
        align-items: center;
        cursor: pointer;
   }

   .card-selected {
        border: 2px solid green; 
   }

   .card-body {
        display: flex;
        flex-direction: column;
        margin-left: 15px;
   }

   input[type=checkbox] {
        width: 20px;
        height: 20px;
   }

`;