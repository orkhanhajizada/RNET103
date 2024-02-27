containers=("code.db" "code.rabbitmq" "code.redis")

for container in "${containers[@]}"
do
    # Konteynerin var olup olmadığını kontrol et
    CONTAINER_ID=$(docker ps -aqf "name=^${container}$")

    if [ -z "$CONTAINER_ID" ]; then
    echo "Konteyner bulunamadı: $container"
    else
    echo "Konteyner bulundu: $container. Durduruluyor..."
    docker stop $CONTAINER_ID
    docker rm $CONTAINER_ID
    echo "Konteyner durduruldu: $container"
    fi
done  