<!doctype html>
<html lang="{{ str_replace('_', '-', app()->getLocale()) }}">
    <head>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">

        <title>Laravel</title>

        <!-- Fonts -->
        <link href="https://fonts.googleapis.com/css?family=Nunito:200,600" rel="stylesheet">

        <!-- Styles -->
        <style>
            html, body {
                background-color: #fff;
                color: #636b6f;
                font-family: 'Nunito', sans-serif;
                font-weight: 200;
                height: 100vh;
                margin: 0;
            }

            .full-height {
                height: 100vh;
            }

            .flex-center {
                align-items: center;
                display: flex;
                justify-content: center;
            }

            .position-ref {
                position: relative;
            }

            .top-right {
                position: absolute;
                right: 10px;
                top: 18px;
            }

            .content {
                text-align: center;
            }

            .title {
                font-size: 84px;
            }

            .links > a {
                color: #636b6f;
                padding: 0 25px;
                font-size: 13px;
                font-weight: 600;
                letter-spacing: .1rem;
                text-decoration: none;
                text-transform: uppercase;
            }

            .m-b-md {
                margin-bottom: 30px;
            }
        </style>
    </head>
    <body>
        <div class="flex-center position-ref full-height">
            @if (Route::has('login'))
                <div class="top-right links">
                    @auth
                        <a href="{{ url('/home') }}">Home</a>
                    @else
                        <a href="#">Bienvenido... {{ session()->get('name') }}</a>
                        @if (session()->get('id')==null)
                            <a href="{{ route('login') }}">Login</a>
                        @endif

                        @if (Route::has('register'))
                            @if (session()->get('roleId') =='ADMIN' )
                                <a href="{{ route('users.create') }}">Crear Usuario</a>
                            @endif
                        @endif

                        @if (session()->get('id') != null)
                            <a href="#" onclick="event.preventDefault();
                            document.getElementById('logout-form').submit();">Cerrar </a>
                            <form id="logout-form" action="{{ route('logout') }}" method="POST" style="display:none;">
                                @csrf
                            </form>
                        @endif

                    @endauth
                </div>
            @endif
            <div class="content">
                <div class="title m-b-md">
                    Biblioteca
                </div>

                <div class="links">
                    @foreach ($menu as $item)
                        @foreach ($item as $value)
                        <a href="{{ route('biblioteca.inicio', [$value->CategoryId, $value->Name])}}">{{$value->Name}}</a>
                        @endforeach
                    @endforeach
                    <br>
                    ID: {{ session()->get('id') }} <br>
                    NAME: {{ session()->get('name') }} <br>
                    USER: {{ session()->get('user') }} <br>
                    ROLEID: {{ session()->get('roleId') }} <br>
                    {{-- PERMISO 1: {{ session()->get('permiso1') }} <br>
                    PERMISO 2: {{ session()->get('permiso2') }} <br>
                    PERMISO 3: {{ session()->get('permiso3') }} <br> --}}

                </div>
            </div>
        </div>
    </body>
</html>
