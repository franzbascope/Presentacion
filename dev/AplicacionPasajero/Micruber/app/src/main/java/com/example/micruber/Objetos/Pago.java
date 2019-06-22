package com.example.micruber.Objetos;

import java.util.Date;

public class Pago {
    private int pagoId;
    private Date fechaPago;
    private int conceptoId;
    private String conceptoDescripcion;
    private String numeroLinea;
    private boolean esIngreso;
    private int usuarioId;
    private int vehiculoId;
    private int lineaId;
    private Date fechaPagoForDisplay;

    public Pago() {
    }

    public Pago(int pagoId, Date fechaPago, int conceptoId, String conceptoDescripcion, String numeroLinea, boolean esIngreso, int usuarioId, int vehiculoId, int lineaId, Date fechaPagoForDisplay) {
        this.pagoId = pagoId;
        this.fechaPago = fechaPago;
        this.conceptoId = conceptoId;
        this.conceptoDescripcion = conceptoDescripcion;
        this.numeroLinea = numeroLinea;
        this.esIngreso = esIngreso;
        this.usuarioId = usuarioId;
        this.vehiculoId = vehiculoId;
        this.lineaId = lineaId;
        this.fechaPagoForDisplay = fechaPagoForDisplay;
    }

    public int getPagoId() {
        return pagoId;
    }

    public void setPagoId(int pagoId) {
        this.pagoId = pagoId;
    }

    public Date getFechaPago() {
        return fechaPago;
    }

    public void setFechaPago(Date fechaPago) {
        this.fechaPago = fechaPago;
    }

    public int getConceptoId() {
        return conceptoId;
    }

    public void setConceptoId(int conceptoId) {
        this.conceptoId = conceptoId;
    }

    public String getConceptoDescripcion() {
        return conceptoDescripcion;
    }

    public void setConceptoDescripcion(String conceptoDescripcion) {
        this.conceptoDescripcion = conceptoDescripcion;
    }

    public String getNumeroLinea() {
        return numeroLinea;
    }

    public void setNumeroLinea(String numeroLinea) {
        this.numeroLinea = numeroLinea;
    }

    public boolean isEsIngreso() {
        return esIngreso;
    }

    public void setEsIngreso(boolean esIngreso) {
        this.esIngreso = esIngreso;
    }

    public int getUsuarioId() {
        return usuarioId;
    }

    public void setUsuarioId(int usuarioId) {
        this.usuarioId = usuarioId;
    }

    public int getVehiculoId() {
        return vehiculoId;
    }

    public void setVehiculoId(int vehiculoId) {
        this.vehiculoId = vehiculoId;
    }

    public int getLineaId() {
        return lineaId;
    }

    public void setLineaId(int lineaId) {
        this.lineaId = lineaId;
    }

    public Date getFechaPagoForDisplay() {
        return fechaPagoForDisplay;
    }

    public void setFechaPagoForDisplay(Date fechaPagoForDisplay) {
        this.fechaPagoForDisplay = fechaPagoForDisplay;
    }
}
