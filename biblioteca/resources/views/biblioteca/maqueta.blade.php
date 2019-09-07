<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <style>
        .position-ref {
            position: relative;
        }

        .top-right {
            position: absolute;
            right: 10px;
            top: 18px;
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
    <title>Biblioteca</title>
  </head>
  <body>

  <div class="container-fluid" style="background-color: #f1f4f6;">
   <!-- Header -->
    <div class="row" style="height: 75px;">
      <div class="col-lg-4">
          <img src="{{asset('img/apache.png')}}" height="75" alt="">
      </div>
      <div class="col-lg-8" >
            <div class="top-right links">
         @if (Route::has('login'))
                @auth
                    <a href="{{ url('/home') }}">Home</a>
                @else
                    <a href="{{ route('login') }}">Login</a>

                    @if (Route::has('register'))
                        <a href="{{ route('register') }}">Register</a>
                    @endif
                @endauth
            </div>
        @endif
      </div>

    </div>
  </div>

  <div class="container">
    <nav class="navbar shadow-lg navbar-expand-lg navbar-light bg-light" style="overflow: auto;">
      <div class="collapse navbar-collapse" id="navbarNavDropdown">
        <ul class="navbar-nav">
          <li class="nav-item  ">
          <a class="nav-link" href="{{ route('inicio')}}">Home <span class="sr-only">(current)</span></a>
          </li>

            @if ($title=='AUTOR')
            @foreach ($menu as $item)
              @foreach ($item as $value)
              <li class="nav-item ">
              <a class="nav-link " href="{{ route('biblioteca.inicio', [$value->AuthorlId, $value->Name, 'AUTOR']) }}">{{$value->Name}}</a>
              </li>
              @endforeach
            @endforeach

            <li class="nav-item ">
                  <a class="nav-link " href="{{ route('biblioteca.inicio', ['99', 'All','AUTOR']) }}">All</a>
              </li>

              @elseif($title=='EDITORIAL')
            @foreach ($menu as $item)
              @foreach ($item as $value)
              <li class="nav-item ">
              <a class="nav-link " href="{{ route('biblioteca.inicio', [$value->EditorialId, $value->Name, 'EDITORIAL']) }}">{{$value->Name}}</a>
              </li>
              @endforeach
            @endforeach

            <li class="nav-item ">
                  <a class="nav-link " href="{{ route('biblioteca.inicio', ['99', 'All','EDITORIAL']) }}">All</a>
              </li>
              @else
              @foreach ($menu as $item)
                @foreach ($item as $value)
                <li class="nav-item ">
                <a class="nav-link " href="{{ route('biblioteca.inicio', [$value->CategoryId, $value->Name, 'CATEGORIA']) }}">{{$value->Name}}</a>
                </li>
                @endforeach
              @endforeach

              <li class="nav-item ">
                    <a class="nav-link " href="{{ route('biblioteca.inicio', ['99', 'All','CATEGORIA']) }}">All</a>
                </li>




              @endif


        </ul>
      </div>
    </nav>
  </div>
  <br>

    <div class="container">

    @yield('seccion')

    </div>


    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
  </body>
</html>
