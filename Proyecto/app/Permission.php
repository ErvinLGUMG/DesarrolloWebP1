<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Permission extends Model
{
    protected $table='permission';
    protected $fillable = ['PermissionId','Name','State'];

    public function getRouteKeyName($value='')
    {
        return 'PermissionId';
    }

    // protected function permissions(){
    //     return $this->belongsToMany('App\Roles');
    // }
}
