for ($i=1; $i -le 100000; $i++) {
    Invoke-WebRequest -Uri http://localhost:30001/pedidos
}
