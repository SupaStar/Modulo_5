create table area
(
    id     int auto_increment
        primary key,
    nombre varchar(50)      null,
    estado bit default b'1' null
)
    charset = latin1;

create table empleado
(
    id_empleado int auto_increment
        primary key,
    nombre      varchar(50) null,
    ap_paterno  varchar(50) null,
    ap_materno  varchar(50) null,
    correo      varchar(50) null,
    num_cel     int         null,
    num_cuenta  varchar(18) null,
    Direccion   text        null
)
    charset = latin1;

create table login
(
    id             int auto_increment
        primary key,
    nombre_usuario varchar(50)  null,
    password       varchar(250) null,
    id_empleado    int          null,
    constraint login_empleado
        foreign key (id_empleado) references empleado (id_empleado)
)
    charset = latin1;

create table sugerencia
(
    id          int auto_increment
        primary key,
    email       varchar(50)      null,
    descripcion text             null,
    token       varchar(255)     null,
    estado      bit default b'1' null
)
    charset = latin1;

create table sugerencia_empleado
(
    id            int auto_increment
        primary key,
    id_sugerencia int null,
    id_empleado   int null,
    constraint sugerencia_empleado_empleado
        foreign key (id_empleado) references empleado (id_empleado),
    constraint sugerencia_empleado_sugerencia
        foreign key (id_sugerencia) references sugerencia (id)
)
    charset = latin1;

create table tipo_queja
(
    id     int auto_increment
        primary key,
    nombre varchar(50)      null,
    estado bit default b'1' null
)
    charset = latin1;

create table urgencia
(
    id          int auto_increment
        primary key,
    nombre      varchar(50)      null,
    ap_paterno  varchar(50)      null,
    ap_materno  varchar(50)      null,
    telefono    varchar(15)      null,
    telefonoF   varchar(15)      null,
    email       varchar(50)      null,
    fecha_nac   date             null,
    nss         int              null,
    descripcion text             null,
    token       varchar(255)     null,
    atendido    bit default b'1' not null,
    estado      bit default b'1' not null,
    id_area     int              null,
    fechaCita   date             not null,
    constraint urgencia_area
        foreign key (id_area) references area (id)
)
    charset = latin1;

create table paciente
(
    id            int auto_increment
        primary key,
    id_urgencia   int  null,
    fecha_entrada date null,
    fecha_salida  date null,
    constraint paciente_urgencia_id_fk
        foreign key (id_urgencia) references urgencia (id)
);

create table estancia
(
    id          int auto_increment
        primary key,
    id_paciente int null,
    piso        int null,
    cama        int null,
    constraint estancia_paciente_id_fk
        foreign key (id_paciente) references paciente (id)
);

create table observaciones
(
    id            int auto_increment
        primary key,
    id_estancia   int          null,
    diagnostico   varchar(200) null,
    observaciones text         null,
    receta        text         null,
    constraint observaciones_estancia_id_fk
        foreign key (id_estancia) references estancia (id)
);

create table operacion
(
    id            int auto_increment
        primary key,
    id_estancia   int  null,
    fecha_entrada date null,
    fecha_salida  date null,
    constraint operacion_estancia_id_fk
        foreign key (id_estancia) references estancia (id)
);

create table queja
(
    id            int auto_increment
        primary key,
    id_cita       int              null,
    email         varchar(50)      null,
    id_tipo_queja int              null,
    descripcion   text             null,
    token         varchar(255)     null,
    estado        bit default b'1' null,
    constraint queja_tipo
        foreign key (id_tipo_queja) references tipo_queja (id),
    constraint queja_urgencia
        foreign key (id_cita) references urgencia (id)
)
    charset = latin1;

create table queja_empleado
(
    id          int auto_increment
        primary key,
    id_queja    int null,
    id_empleado int null,
    constraint queja_empleado_empleado
        foreign key (id_empleado) references empleado (id_empleado),
    constraint queja_empleado_queja
        foreign key (id_queja) references queja (id)
)
    charset = latin1;

create table solucion_queja
(
    id       int auto_increment
        primary key,
    id_queja int  null,
    solucion text null,
    constraint solucion_queja_queja_id_fk
        foreign key (id_queja) references queja (id)
);

create table urgencias_empleado
(
    id          int auto_increment
        primary key,
    id_urgencia int null,
    id_empleado int null,
    constraint tabla_empleado
        foreign key (id_empleado) references empleado (id_empleado),
    constraint tabla_urgencia
        foreign key (id_urgencia) references urgencia (id)
)
    charset = latin1;

create table usuarios_paciente
(
    id          int auto_increment
        primary key,
    id_estancia int          null,
    usuario     varchar(100) null,
    password    varchar(255) null,
    constraint usuarios_paciente_estancia_id_fk
        foreign key (id_estancia) references estancia (id)
);


