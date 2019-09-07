<?php

namespace App\Http\Middleware;

use Closure;

class AdminMiddleware
{
    public function handle($request, Closure $next)
    {
        if (session()->get('roleId') == 'ADMIN') {
            return $next($request);
        }else{
            return redirect()->route('inicio');
        }
    }
}
