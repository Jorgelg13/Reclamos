<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Modulos extends Model
{
     protected $table = 'modulos';
     protected $guarded = ['id'];
     public $timestamps = false;

     public function mensajes()
     {
         return $this->hasMany('App\Mensajeria', 'modulo', 'id');
     }
}
