import Swal from 'sweetalert2';

export function showAlert(type, title, message, timer = 5000, isToast = false) {
  Swal.fire({
    icon: type,  // 'success', 'error', 'info', 'warning'
    title: title,
    text: message,
    timer: isToast ? timer : 1500, // Tempo para o toast (caso não seja um toast, será 1500ms)
    showConfirmButton: false,  // Remover o botão de confirmação
    toast: isToast,  // Define se será um toast ou um alerta normal
    position: 'top-end',  // Definir a posição para o canto superior direito
    background: '#fff',  // Adiciona fundo branco para o toast (se necessário)
    customClass: {
      popup: 'custom-toast',  // Personalize a classe se necessário
    },
  });
}
