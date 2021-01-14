import styled from 'styled-components';

export const Container = styled.div`

   height: 200px;
   display: flex;
   justify-content: center;
   flex-direction: column; 
   align-items: center;
   background-color: #285d96;
   color: #fff;
   text-align: center;
   border-radius: 3px;
   
   .title-primary {
      font-size: 0.6em;
   }

   .title-secondary {
     font-size: 1.6em;
     margin: 3px 0px;
   }

   .divisor {
     width: 30px;
     height: 1px;
     background-color: #fff;
     margin: 3px 0px;
   }

   .message {
     margin: 15px 0px;
   }
`;