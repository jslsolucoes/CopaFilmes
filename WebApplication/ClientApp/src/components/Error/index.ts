import withReactContent from 'sweetalert2-react-content';
import Swal from 'sweetalert2';
const alert = withReactContent(Swal);

const error = (title: string, message: string) => {
    alert.fire({
        showClass: {
            popup: 'swal2-show',
            backdrop: 'swal2-backdrop-show',
            icon: 'swal2-icon-show'
        },
        hideClass: {
            popup: 'swal2-hide',
            backdrop: 'swal2-backdrop-hide',
            icon: 'swal2-icon-hide'
        },
        title,
        text: message,
        icon: 'error',
        confirmButtonText: 'Ok'
    })
};

export default error;