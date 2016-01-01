// Copyright (c) 2009-2011 Intel Corporation
// All rights reserved.
//
// WARRANTY DISCLAIMER
//
// THESE MATERIALS ARE PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL INTEL OR ITS
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
// EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY
// OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY OR TORT (INCLUDING
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THESE
// MATERIALS, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Intel Corporation is the author of the Materials, and requests that all
// problem reports or change requests be submitted to it directly


__kernel void bitonic_sort(__global int4* data, const uint stage, const uint pass, const uint dir)
{
    size_t i = get_global_id(0);
    int4 srcLeft, srcRight, mask;
    int4 imask10 = (int4){0,  0, -1, -1};
    int4 imask11 = (int4){0, -1,  0, -1};

    if (stage > 0)
    {
        if (pass > 0)    // upper level pass, exchange between two fours
        {
            size_t r = 1 << (pass - 1);
            size_t lmask = r - 1;
            size_t left = ((i>>(pass-1)) << pass) + (i & lmask);
            size_t right = left + r;

            srcLeft = data[left];
            srcRight = data[right];
            mask = srcLeft < srcRight;

            int4 imin = (srcLeft & mask) | (srcRight & ~mask);
            int4 imax = (srcLeft & ~mask) | (srcRight & mask);

            if( ((i>>(stage-1)) & 1) ^ dir )
            {
                data[left]  = imin;
                data[right] = imax;
            }
            else
            {
                data[right] = imin;
                data[left]  = imax;
            }
        }
        else    // last pass, sort inside one four
        {
            srcLeft = data[i];
            srcRight = srcLeft.zwxy;
            mask = (srcLeft < srcRight) ^ imask10;

            if(((i >> stage) & 1) ^ dir)
            {
                srcLeft = (srcLeft & mask) | (srcRight & ~mask);
                srcRight = srcLeft.yxwz;
                mask = (srcLeft < srcRight) ^ imask11;
                data[i] = (srcLeft & mask) | (srcRight & ~mask);
            }
            else
            {
                srcLeft = (srcLeft & ~mask) | (srcRight & mask);
                srcRight = srcLeft.yxwz;
                mask = (srcLeft < srcRight) ^ imask11;
                data[i] = (srcLeft & ~mask) | (srcRight & mask);
            }
        }
    }
    else    // first stage, sort inside one four
    {
        int4 imask0 = (int4){0, -1, -1,  0};
        srcLeft = data[i];
        srcRight = srcLeft.yxwz;
        mask = (srcLeft < srcRight) ^ imask0;
        if( dir )
            srcLeft = (srcLeft & mask) | (srcRight & ~mask);
        else
            srcLeft = (srcLeft & ~mask) | (srcRight & mask);

        srcRight = srcLeft.zwxy;
        mask = (srcLeft < srcRight) ^ imask10;

        if((i & 1) ^ dir)
        {
            srcLeft = (srcLeft & mask) | (srcRight & ~mask);
            srcRight = srcLeft.yxwz;
            mask = (srcLeft < srcRight) ^ imask11;
            data[i] = (srcLeft & mask) | (srcRight & ~mask);
        }
        else
        {
            srcLeft = (srcLeft & ~mask) | (srcRight & mask);
            srcRight = srcLeft.yxwz;
            mask = (srcLeft < srcRight) ^ imask11;
            data[i] = (srcLeft & ~mask) | (srcRight & mask);
        }
    }
}