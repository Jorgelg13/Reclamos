<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Mensajeros extends Model
{
     protected $table = 'mensajeros';
     protected $guarded = ['id'];
     public $timestamps = false;

     public function mensajes()
     {
         return $this->hasMany('App\Mensajeria', 'mensajero', 'id');
     }

     public function observaciones()
     {
         return $this->hasMany('App\ObservacionEntrega', 'mensajero', 'id');
     }
}
