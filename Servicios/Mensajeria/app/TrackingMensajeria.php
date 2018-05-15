<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class TrackingMensajeria extends Model
{
     protected $table = 'tracking_mensajeria';
     protected $guarded = ['id'];
     public $timestamps = false;
     
     public function observacion()
     {
         return $this->belongsTo('App\EstadoMensajeria', 'estado', 'id');
     }

     public function mensaje()
     {
         return $this->belongsTo('App\Mensajeria', 'mensajeria', 'id');
     }

     public function observaciones()
     {
         return $this->hasMany('App\ObservacionEntrega', 'tracking', 'id');
     }
}
