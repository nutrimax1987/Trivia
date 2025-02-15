﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

/// <summary>
/// Summary description for CometAsyncResult
/// </summary>
public class CometAsyncResult : IAsyncResult
{
    private HttpContext _currentContext;
    private AsyncCallback _asyncCallback;
    private Object _extraData;

    private Boolean _isCompleted;
    private Guid _clientGuid;  // Generates each time when HttpContext different - Globally unique identifier is a 128-bit
    private ManualResetEvent _callCompleteEvent = null;

    public CometAsyncResult(HttpContext currentContext, AsyncCallback asyncCallback, Object extraData)
    {
        _currentContext = currentContext;
        _asyncCallback = asyncCallback;
        _extraData = extraData;

        _isCompleted = false;
    }

    public void CompleteRequest()
    {
        _isCompleted = true;

        lock (this)
        {
            if (_callCompleteEvent != null)
                _callCompleteEvent.Set();
        }

        if (_asyncCallback != null)
        {
            _asyncCallback(this);
        }
    }

    public HttpContext HttpContext
    {
        get
        {
            return _currentContext;
        }
        set
        {
            _currentContext = value;
        }
    }

    public AsyncCallback AsyncCallBack
    {
        get
        {
            return _asyncCallback;
        }
        set
        {
            _asyncCallback = value;
        }
    }

    public Object ExtraData
    {
        get
        {
            return _extraData;
        }
        set
        {
            _extraData = value;
        }
    }

    public Guid ClientGuid
    {
        get
        {
            return _clientGuid;
        }
        set
        {
            _clientGuid = value;
        }
    }  

    // IAsyncResult implementations
    public Boolean CompletedSynchronously
    {
        get
        {
            return false;
        }
    }

    public Boolean IsCompleted
    {
        get
        {
            return _isCompleted;
        }
    }

    public Object AsyncState
    {
        get
        {
            return _extraData;
        }
    }

    public WaitHandle AsyncWaitHandle
    {
        get
        {
            lock (this)
            {
                if (_callCompleteEvent == null)
                    _callCompleteEvent = new ManualResetEvent(false);

                return _callCompleteEvent;
            }
        }
    }
}
