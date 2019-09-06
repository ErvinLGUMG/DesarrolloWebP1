<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Roles extends Model
{
    protected $table="roles";

    protected function users(){
        return $this->belongsToMany('App\Users');
    }

    protected function permissions(){
        return $this->belongsToMany('App\Permisions');
    }
}
