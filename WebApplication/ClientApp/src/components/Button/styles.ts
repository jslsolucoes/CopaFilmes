import styled from 'styled-components';

export const Container = styled.div`

      button {
        background-color: #f14d4d;
        color: #fff;
        border: 1px solid #f14d4d;
        border-radius: 3px;
        padding: 10px;
        cursor: pointer;
      }

      button:disabled {
        background-color: #d29393;
        cursor: not-allowed;
      }

`;